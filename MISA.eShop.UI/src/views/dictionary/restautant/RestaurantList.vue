<template>
  <div class="contenBody">
    <!-- header của content  -->
    <div class="contentHeader">
      <!-- nút thêm  -->
      <button
        title="Thêm mới cửa hàng"
        class="contentHeaderButton"
        @click="openDialog"
      >
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
        @resetDataRestaurant="resetDataRestaurant"
      />
      <!-- nhân bản  -->
      <button
        title="Nhân bản thêm một cửa hàng nữa"
        class="contentHeaderButton"
      >
        <div class="iconHeader">
          <div class="iconDupplicate"></div>
        </div>
        <div class="iconText">Nhân bản</div>
      </button>
      <!-- sửa  -->
      <button
        title="Chỉnh sửa thông tin cửa hàng"
        class="contentHeaderButton"
        @click="openDialogToEdit"
      >
        <div class="iconHeader">
          <div class="iconEdit"></div>
        </div>
        <div class="iconText">Sửa</div>
      </button>
      <!-- xóa  -->
      <button
        title="Xóa cửa hàng"
        class="contentHeaderButton"
        @click="openPopup"
      >
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
    <div class="gridTable" >
      <table class="tableContent">
        <thead>
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
                <input class="searchField" v-model="filterRestaurantName" />
              </div>
            </th>
            <th width="45%">
              Địa chỉ
              <div class="filterField">
                <div class="iconSearch">*</div>
                <input class="searchField" />
              </div>
            </th>
            <th width="8%">
              Số điện thoại
              <div class="filterField">
                <div class="iconSearch">*</div>
                <input class="searchField" v-model="filterPhone" />
              </div>
            </th>
            <th width="8%">
              Trạng thái
              <div class="filterField">
                <!-- <div class="iconSearch">*</div>
                <input class="searchField" /> -->
                <select style="width: 100%">
                  <option value="1">Đang hoạt động</option>
                  <option value="2">Ngừng hoạt động</option>
                </select>
              </div>
            </th>
          </tr>
        </thead>
        <tbody>
          <tr
            class="tableRow"
            v-for="(restaurant, index) in restaurants"
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
                  Đang hoạt động
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
  props: {},
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
    //

  },
  methods: {
    resetDataRestaurant() {
      this.restaurantToBinding = {
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
      };
    },
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
        this.restaurantToBinding = this.restaurantSelected;
        this.$store.dispatch("openDialog");
      } else {
        //nếu không, bắt chọn
        this.$notify({
          title: "Important message",
          text: "Chọn cửa hàng cần sửa !",
          type: "warn",
        });
      }
    },
    /**
     * Mở popup xác nhận xóa
     */
    openPopup() {
      if (this.isActive > -1) {
        this.$store.dispatch("openPopup");
      } else {
        this.$notify({
          title: "Important message",
          text: "Chọn cửa hàng cần xóa !",
          type: "warn",
        });
      }
    },

    /**
     * Chọn dòng hiện tại
     */
    rowOnClick(restaurant, index) {
      //gán restaurantTemp bằng restaurant đang chọn
      // this.restaurantToBinding = restaurant;
      this.restaurantSelected = restaurant;
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
      //TODO filter
      filterRestaurantCode: [],
      filterRestaurantName: "",
      filterPhone: "",
      nations: [],
      citiesFromNation: [],
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
      restaurantSelected: {
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
      restaurantDefault: {
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
          restaurantCode: "Res 01",
          restaurantName: "Res01",
          address: "15 Duy Tân",
          phoneNumber: "01662804035",
          taxCode: "AA",
          nationID: "00000000-0000-0000-0000-000000000000",
          cityID: "00000000-0000-0000-0000-000000000000",
          districtID: "00000000-0000-0000-0000-000000000000",
          communeID: "00000000-0000-0000-0000-000000000000",
          streetID: "00000000-0000-0000-0000-000000000000",
        },
        {
          restaurantID: "00000000-0000-0000-0000-000000000000",
          restaurantCode: "Res 01",
          restaurantName: "Res01",
          address: "15 Duy Tân",
          phoneNumber: "01662804035",
          taxCode: "AA",
          nationID: "00000000-0000-0000-0000-000000000000",
          cityID: "00000000-0000-0000-0000-000000000000",
          districtID: "00000000-0000-0000-0000-000000000000",
          communeID: "00000000-0000-0000-0000-000000000000",
          streetID: "00000000-0000-0000-0000-000000000000",
        },
        {
          restaurantID: "00000000-0000-0000-0000-000000000000",
          restaurantCode: "Res 01",
          restaurantName: "Res01",
          address: "15 Duy Tân",
          phoneNumber: "01662804035",
          taxCode: "AA",
          nationID: "00000000-0000-0000-0000-000000000000",
          cityID: "00000000-0000-0000-0000-000000000000",
          districtID: "00000000-0000-0000-0000-000000000000",
          communeID: "00000000-0000-0000-0000-000000000000",
          streetID: "00000000-0000-0000-0000-000000000000",
        },
        {
          restaurantID: "00000000-0000-0000-0000-000000000000",
          restaurantCode: "Res 01",
          restaurantName: "Res01",
          address: "15 Duy Tân",
          phoneNumber: "01662804035",
          taxCode: "AA",
          nationID: "00000000-0000-0000-0000-000000000000",
          cityID: "00000000-0000-0000-0000-000000000000",
          districtID: "00000000-0000-0000-0000-000000000000",
          communeID: "00000000-0000-0000-0000-000000000000",
          streetID: "00000000-0000-0000-0000-000000000000",
        },
        {
          restaurantID: "00000000-0000-0000-0000-000000000000",
          restaurantCode: "Res 01",
          restaurantName: "Res01",
          address: "15 Duy Tân",
          phoneNumber: "01662804035",
          taxCode: "AA",
          nationID: "00000000-0000-0000-0000-000000000000",
          cityID: "00000000-0000-0000-0000-000000000000",
          districtID: "00000000-0000-0000-0000-000000000000",
          communeID: "00000000-0000-0000-0000-000000000000",
          streetID: "00000000-0000-0000-0000-000000000000",
        },
        {
          restaurantID: "00000000-0000-0000-0000-000000000000",
          restaurantCode: "Res 01",
          restaurantName: "Res01",
          address: "15 Duy Tân",
          phoneNumber: "01662804035",
          taxCode: "AA",
          nationID: "00000000-0000-0000-0000-000000000000",
          cityID: "00000000-0000-0000-0000-000000000000",
          districtID: "00000000-0000-0000-0000-000000000000",
          communeID: "00000000-0000-0000-0000-000000000000",
          streetID: "00000000-0000-0000-0000-000000000000",
        },
        {
          restaurantID: "00000000-0000-0000-0000-000000000000",
          restaurantCode: "Res 01",
          restaurantName: "Res01",
          address: "15 Duy Tân",
          phoneNumber: "01662804035",
          taxCode: "AA",
          nationID: "00000000-0000-0000-0000-000000000000",
          cityID: "00000000-0000-0000-0000-000000000000",
          districtID: "00000000-0000-0000-0000-000000000000",
          communeID: "00000000-0000-0000-0000-000000000000",
          streetID: "00000000-0000-0000-0000-000000000000",
        },
        {
          restaurantID: "00000000-0000-0000-0000-000000000000",
          restaurantCode: "Res 01",
          restaurantName: "Res01",
          address: "15 Duy Tân",
          phoneNumber: "01662804035",
          taxCode: "AA",
          nationID: "00000000-0000-0000-0000-000000000000",
          cityID: "00000000-0000-0000-0000-000000000000",
          districtID: "00000000-0000-0000-0000-000000000000",
          communeID: "00000000-0000-0000-0000-000000000000",
          streetID: "00000000-0000-0000-0000-000000000000",
        },
        {
          restaurantID: "00000000-0000-0000-0000-000000000000",
          restaurantCode: "Res 01",
          restaurantName: "Res01",
          address: "15 Duy Tân",
          phoneNumber: "01662804035",
          taxCode: "AA",
          nationID: "00000000-0000-0000-0000-000000000000",
          cityID: "00000000-0000-0000-0000-000000000000",
          districtID: "00000000-0000-0000-0000-000000000000",
          communeID: "00000000-0000-0000-0000-000000000000",
          streetID: "00000000-0000-0000-0000-000000000000",
        },
        {
          restaurantID: "00000000-0000-0000-0000-000000000000",
          restaurantCode: "Res 01",
          restaurantName: "Res01",
          address: "15 Duy Tân",
          phoneNumber: "01662804035",
          taxCode: "AA",
          nationID: "00000000-0000-0000-0000-000000000000",
          cityID: "00000000-0000-0000-0000-000000000000",
          districtID: "00000000-0000-0000-0000-000000000000",
          communeID: "00000000-0000-0000-0000-000000000000",
          streetID: "00000000-0000-0000-0000-000000000000",
        },
        {
          restaurantID: "00000000-0000-0000-0000-000000000000",
          restaurantCode: "Res 01",
          restaurantName: "Res01",
          address: "15 Duy Tân",
          phoneNumber: "01662804035",
          taxCode: "AA",
          nationID: "00000000-0000-0000-0000-000000000000",
          cityID: "00000000-0000-0000-0000-000000000000",
          districtID: "00000000-0000-0000-0000-000000000000",
          communeID: "00000000-0000-0000-0000-000000000000",
          streetID: "00000000-0000-0000-0000-000000000000",
        },
        {
          restaurantID: "00000000-0000-0000-0000-000000000000",
          restaurantCode: "Res 01",
          restaurantName: "Res01",
          address: "15 Duy Tân",
          phoneNumber: "01662804035",
          taxCode: "AA",
          nationID: "00000000-0000-0000-0000-000000000000",
          cityID: "00000000-0000-0000-0000-000000000000",
          districtID: "00000000-0000-0000-0000-000000000000",
          communeID: "00000000-0000-0000-0000-000000000000",
          streetID: "00000000-0000-0000-0000-000000000000",
        },
        {
          restaurantID: "00000000-0000-0000-0000-000000000000",
          restaurantCode: "Res 01",
          restaurantName: "Res01",
          address: "15 Duy Tân",
          phoneNumber: "01662804035",
          taxCode: "AA",
          nationID: "00000000-0000-0000-0000-000000000000",
          cityID: "00000000-0000-0000-0000-000000000000",
          districtID: "00000000-0000-0000-0000-000000000000",
          communeID: "00000000-0000-0000-0000-000000000000",
          streetID: "00000000-0000-0000-0000-000000000000",
        },
        {
          restaurantID: "00000000-0000-0000-0000-000000000000",
          restaurantCode: "Res 01",
          restaurantName: "Res01",
          address: "15 Duy Tân",
          phoneNumber: "01662804035",
          taxCode: "AA",
          nationID: "00000000-0000-0000-0000-000000000000",
          cityID: "00000000-0000-0000-0000-000000000000",
          districtID: "00000000-0000-0000-0000-000000000000",
          communeID: "00000000-0000-0000-0000-000000000000",
          streetID: "00000000-0000-0000-0000-000000000000",
        },
        {
          restaurantID: "00000000-0000-0000-0000-000000000000",
          restaurantCode: "Res 01",
          restaurantName: "Res01",
          address: "15 Duy Tân",
          phoneNumber: "01662804035",
          taxCode: "AA",
          nationID: "00000000-0000-0000-0000-000000000000",
          cityID: "00000000-0000-0000-0000-000000000000",
          districtID: "00000000-0000-0000-0000-000000000000",
          communeID: "00000000-0000-0000-0000-000000000000",
          streetID: "00000000-0000-0000-0000-000000000000",
        },
        {
          restaurantID: "00000000-0000-0000-0000-000000000000",
          restaurantCode: "Res 01",
          restaurantName: "Res01",
          address: "15 Duy Tân",
          phoneNumber: "01662804035",
          taxCode: "AA",
          nationID: "00000000-0000-0000-0000-000000000000",
          cityID: "00000000-0000-0000-0000-000000000000",
          districtID: "00000000-0000-0000-0000-000000000000",
          communeID: "00000000-0000-0000-0000-000000000000",
          streetID: "00000000-0000-0000-0000-000000000000",
        },
        {
          restaurantID: "00000000-0000-0000-0000-000000000000",
          restaurantCode: "Res 01",
          restaurantName: "Res01",
          address: "15 Duy Tân",
          phoneNumber: "01662804035",
          taxCode: "AA",
          nationID: "00000000-0000-0000-0000-000000000000",
          cityID: "00000000-0000-0000-0000-000000000000",
          districtID: "00000000-0000-0000-0000-000000000000",
          communeID: "00000000-0000-0000-0000-000000000000",
          streetID: "00000000-0000-0000-0000-000000000000",
        },
        {
          restaurantID: "00000000-0000-0000-0000-000000000000",
          restaurantCode: "Res 01",
          restaurantName: "Res01",
          address: "15 Duy Tân",
          phoneNumber: "01662804035",
          taxCode: "AA",
          nationID: "00000000-0000-0000-0000-000000000000",
          cityID: "00000000-0000-0000-0000-000000000000",
          districtID: "00000000-0000-0000-0000-000000000000",
          communeID: "00000000-0000-0000-0000-000000000000",
          streetID: "00000000-0000-0000-0000-000000000000",
        },
        {
          restaurantID: "00000000-0000-0000-0000-000000000000",
          restaurantCode: "Res 01",
          restaurantName: "Res01",
          address: "15 Duy Tân",
          phoneNumber: "01662804035",
          taxCode: "AA",
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