<template>
  <div class="contenBody">
    <!-- header của content  -->
    <div class="contentHeader">
      <!-- nút thêm  -->
      <button class="contentHeaderButton" @click="openDialog">
        <div class="iconHeader">
          <div class="iconAdd"></div>
        </div>
        <div class="iconText">Thêm mới</div>
      </button>

      <Dialog
        v-if="isShow"
        :restaurantToBinding="restaurantToBinding"
        :cities="citiesFromNation"
        ref="details"
      />
      <!-- nhân bản  -->
      <button class="contentHeaderButton">
        <div class="iconHeader">
          <div class="iconDupplicate"></div>
        </div>
        <div class="iconText">Nhân bản</div>
      </button>
      <!-- sửa  -->
      <button class="contentHeaderButton" @click="openDialogToEdit">
        <div class="iconHeader">
          <div class="iconEdit"></div>
        </div>
        <div class="iconText">Sửa</div>
      </button>
      <!-- xóa  -->
      <button class="contentHeaderButton" @click="openPopup">
        <div class="iconHeader">
          <div class="iconDelete"></div>
        </div>
        <div class="iconText">Xóa</div>
      </button>

      <Popup
        v-if="showPopup"
        :idToDelete="idToDelete"
        :nameNeedDelete="nameNeedDelete"
      />
      <!-- nạp  -->
      <button class="contentHeaderButton">
        <div class="iconHeader">
          <div class="iconImport"></div>
        </div>
        <div class="iconText">Nạp</div>
      </button>
    </div>

    <!-- table  -->
    <div class="gridTable" v-if="renderComponent">
      <table class="tableContent">
        <thead v-columns-resizable>
          <tr class="filter">
            <th width="10%">
              Mã cửa hàng
              <div class="filterField">
                <div class="iconSearch">*</div>
                <input class="searchField" />
              </div>
            </th>
            <th width="15%">
              Tên cửa hàng
              <div class="filterField">
                <div class="iconSearch">*</div>
                <input class="searchField" />
              </div>
            </th>
            <th width="45%">
              Địa chỉ
              <div class="filterField">
                <div class="iconSearch">*</div>
                <input class="searchField" />
              </div>
            </th>
            <th width="10%">
              Số điện thoại
              <div class="filterField">
                <div class="iconSearch">*</div>
                <input class="searchField" v-model="filterPhone"/>
              </div>
            </th>
            <th width="5%">
              Mã số thuế
              <div class="filterField">
                <div class="iconSearch">*</div>
                <input class="searchField" />
              </div>
            </th>
          </tr>
        </thead>
        <tbody>
          <tr
            class="tableRow"
            v-for="(restaurant, index) in filteredAsset"
            :key="index"
            :class="{ hightlight: isActive == index }"
            @click="rowOnClick(restaurant, index)"
          >
            <td>
              <div class="cell">
                {{ restaurant.restaurantCode }}
              </div>
            </td>
            <td>
              <div class="cell">
                {{ restaurant.restaurantName }}
              </div>
            </td>
            <td>
              <div class="cell">
                {{ restaurant.address }}
              </div>
            </td>
            <td>
              <div class="cell">
                {{ restaurant.phoneNumber }}
              </div>
            </td>
            <td>
              <div class="cell">
                {{ restaurant.taxCode }}
              </div>
            </td>
          </tr>
        </tbody>
      </table>
    </div>

    <div class="contentFooter">
      <div class="contentFooterLeft">
        <button class="buttonPage">
          <div class="firstPage"></div>
        </button>
        <button class="buttonPage">
          <div class="prevPage"></div>
        </button>
        <div class="contentFooterPaging">
          <span>Trang </span>
          <div class="currentPage">1</div>
          <span> trên </span>
          <div class="totalPage">1</div>
        </div>
        <button class="buttonPage">
          <div class="nextPage"></div>
        </button>
        <button class="buttonPage">
          <div class="lastPage"></div>
        </button>
        <button class="buttonPage">
          <div class="refresh"></div>
        </button>
        <select class="typePage">
          <option>50</option>
        </select>
      </div>

      <div class="contentFooterRight">
        <span>Hiển thị 1- 10 trên {{ restaurants.length }} kết quả</span>
      </div>
    </div>
  </div>
</template>

<script>
import * as axios from "axios";
import Dialog from "./RestaurantListDetail";
import Popup from "../popup/PopupDelete";
export default {
  name: "Restaurant",
  components: {
    Dialog,
    Popup,
  },
  computed: {
    /**
     * trả về trạng thái hiển thị form thêm/ sửa
     */
    isShow() {
      return this.$store.state.isShow;
    },
    /**
     * trả về trạng thái hiển thị popup xóa
     */
    showPopup() {
      return this.$store.state.showPopup;
    },
    filteredAsset() {
      let 
        filterPhoneNumber = this.filterPhone;

      return this.restaurants.filter(function (item) {
        let filtered = true;
        if (filtered) {
          if (filterPhoneNumber && filterPhoneNumber.length > 0) {
            filtered =
              item.phoneNumber.includes(filterPhoneNumber);
          }
        }
        return filtered;
      });
    },
  },
  methods: {
    /**
     * Mở forrm để thêm mới
     * createdby vtthien 21/02/21
     */
    openDialog() {
      this.$store.dispatch("openDialog");
    },

    /**
     * Mở form để sửa
     */
    async openDialogToEdit() {
      // nếu đã chọn cửa hàng
      if (this.isActive > -1) {
        // lấy cửa hàng đã chọn theo id
        const res = await axios.get(
          "https://localhost:44305/api/v1/restaurants/" + this.idToDelete
        );
        if (res) {
          // console.log(res);
          console.log(res.data.data);
          this.restaurantToBinding = res.data.data;

          //get list city by nationID
          this.citiesFromNation = (
            await axios.get(
              "https://localhost:44305/api/Cities/ByParent/" +
                this.restaurantToBinding.nationID
            )
          ).data.data;
          // console.log("thong tin tinh");
          // console.log(this.citiesFromNation);
        } else {
          console.log("K lấy được api get cửa hàng theo id");
        }
        this.$store.dispatch("openDialog");
      } else {
        //nếu không, bắt chọn
        alert("Chọn cửa hàng cần sửa");
      }
    },

    /**
     * Mở popup xác nhận xóa
     */
    openPopup() {
      if (this.isActive > -1) {
        this.$store.dispatch("openPopup");
      } else {
        alert("Chọn cửa hàng cần xóa");
      }
    },

    /**
     * Chọn dòng hiện tại
     */
    rowOnClick(restaurant, index) {
      //gán restaurantTemp bằng restaurant đang chọn
      this.restaurantTemp = restaurant;
      // active row đang chọn theo index
      this.isActive = index;
      //gán id cần xóa bằng id của cửa hàng hiện tại
      this.idToDelete = restaurant.restaurantID;
      //gán tên cửa hàng cần xóa
      this.nameNeedDelete = restaurant.restaurantName;
    },

    

  },
  data() {
    return {
      filterRestaurantCode:[],
      filterRestaurantName:[],
      filterPhone:"",
      nations: [],
      citiesFromNation: [],
      renderComponent: true,
      idToDelete: "",
      nameNeedDelete: "",
      isActive: -1,
      isEdit: false,
      restaurantToBinding: {
        restaurantID: "00000000-0000-0000-0000-000000000000",
        restaurantCode: "",
        restaurantName: "",
        address: "",
        phoneNumber: "",
        taxCode: "",
        nationID: "00000000-0000-0000-0000-000000000000",
        cityID: "00000000-0000-0000-0000-000000000000",
        districtID: "00000000-0000-0000-0000-000000000000",
        communeID: "00000000-0000-0000-0000-000000000000",
        streetID: "00000000-0000-0000-0000-000000000000",
      },
      restaurants: [
        {
          restaurantID: "00000000-0000-0000-0000-000000000000",
        restaurantCode: "",
        restaurantName: "",
        address: "",
        phoneNumber: "",
        taxCode: "",
        nationID: "00000000-0000-0000-0000-000000000000",
        cityID: "00000000-0000-0000-0000-000000000000",
        districtID: "00000000-0000-0000-0000-000000000000",
        communeID: "00000000-0000-0000-0000-000000000000",
        streetID: "00000000-0000-0000-0000-000000000000",
        },
      ],
    };
  },

  //Gọi api lấy thông tin cửa hàng
  async created() {
    const response = await axios.get(
      "https://localhost:44305/api/v1/restaurants"
    );
    this.restaurants = response.data.data;
  },
};
</script>
<style scoped>
.filter .filterField {
  height: 46px;
  width: 100%;
  padding: 4px;
  display: flex;
}
.iconSearch {
  border: 1px solid #9e9e9e;
  border-radius: 4px;
  margin: 1px;
  height: 100%;
  width: 40px;
  line-height: 40px;
  text-align: center;
}
.searchField {
  margin: 1px;
  height: 100%;
  width: calc(100% - 40px);
  border-radius: 4px;
  border: 1px solid #9e9e9e;
  /* width: 100%; */
  /* background-color: red; */
}
.hightlight {
  background-color: #026b97;
}
</style>