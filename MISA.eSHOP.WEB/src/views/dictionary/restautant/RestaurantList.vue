<template>
  <div class="contenBody">
    <!-- header của content  -->
    <div class="contentHeader">
      <!-- nút thêm  -->
      <button 
      class="contentHeaderButton" 
      @click="openDialog"
      >
        <div class="iconHeader">
          <div class="iconAdd"></div>
        </div>
        <div class="iconText">Thêm mới</div>
      </button>

      <Dialog v-if="isShow" />

      <!-- nhân bản  -->
      <button class="contentHeaderButton">
        <div class="iconHeader">
          <div class="iconDupplicate"></div>
        </div>
        <div class="iconText">Nhân bản</div>
      </button>
      <!-- sửa  -->
      <button 
      class="contentHeaderButton" 
      @click="openDialog"
      >
        <div class="iconHeader">
          <div class="iconEdit"></div>
        </div>
        <div class="iconText">Sửa</div>
      </button>
      <!-- xóa  -->
      <button 
      class="contentHeaderButton" 
      @click="openPopup"
      >
        <div class="iconHeader">
          <div class="iconDelete"></div>
        </div>
        <div class="iconText">Xóa</div>
      </button>
      <Popup v-if="showPopup" />
      <!-- nạp  -->
      <button class="contentHeaderButton">
        <div class="iconHeader">
          <div class="iconImport"></div>
        </div>
        <div class="iconText">Nạp</div>
      </button>
    </div>

    <!-- table  -->
    <div class="gridTable">
      <table class="tableContent">
        <thead v-columns-resizable>
          <tr class="filter">
            <th width="10%">
              Mã cửa hàng
              <div 
              class="filterField" 
              style="display: flex"
              >
                <div class="iconSearch">*</div>
                <input class="searchField" />
              </div>
            </th>
            <th width="20%">
              Tên cửa hàng
              <div 
              class="filterField" 
              style="display: flex"
              >
                <div class="iconSearch">*</div>
                <!-- <div class="searchField"></div>  -->
                <input class="searchField" />
              </div>
            </th>
            <th width="45%">
              Địa chỉ
              <div 
              class="filterField" 
              style="display: flex"
              >
                <div class="iconSearch">*</div>
                <!-- <div class="searchField"></div>  -->
                <input class="searchField" />
              </div>
            </th>
            <th width="10%">
              Số điện thoại
              <div 
              class="filterField" 
              style="display: flex"
              >
                <div class="iconSearch">*</div>
                <!-- <div class="searchField"></div> -->
                <input class="searchField" />
              </div>
            </th>
            <th width="5%">
              Mã số thuế
              <div 
              class="filterField" 
              style="display: flex"
              >
                <div class="iconSearch">*</div>
                <input class="searchField" />
              </div>
            </th>
          </tr>
        </thead>
        <tbody>
          <tr
            class="tableRow"
            v-for="restaurant in restaurants"
            :key="restaurant.EmployeeCode"
            @click="rowOnClick(restaurant)"
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
        <span>Hiển thị 1- 10 trên 10 kết quả</span>
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
    isShow() {
      return this.$store.state.isShow;
    },
    showPopup() {
      return this.$store.state.showPopup;
    },
  },
  methods: {

    /**
     * Mở forrm
     * createdby vtthien 21/02/21
     */
    openDialog() {
      this.$store.dispatch("openDialog");
    },

    /**
     * Mở popup xác nhận xóa
     */
    openPopup() {
      this.$store.dispatch("openPopup");
    },

    /**
     * Chọn dòng hiện tại
     */
    rowOnClick(restaurant) {
      this.restaurantTemp = restaurant;
    },
  },
  data() {
    return {
      restaurants: [
        {
          RestaurantCode: "MS1",
          RestaurantName: "Thiên",
          Address: " Ha Noi",
          PhoneNumber: "09669856810",
          Status: "Đang làm việc",
        },
      ],
    };
  },
  /**
   * Gọi api lấy thông tin cửa hàng
   */
  async created() {
    const response = await axios.get("https://localhost:44305/api/v1/restaurants");
    this.restaurants = response.data.data;
  },
};
</script>
<style scoped>
.filter .filterField {
  height: 40px;
  width: 100%;
  padding: 4px;
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
</style>