<template>
  <div>
    <div class="modal">
      <!-- nền xám sau dialog  -->
      <div class="modalMask"></div>
      <div class="dialog">
        <!-- header của dialog  -->
        <div class="dialogHeader">
          <button class="closeDialog" @click="closeDialog">
            <svg
              xmlns="http://www.w3.org/2000/svg"
              width="24"
              height="24"
              viewBox="0 0 24 24"
              fill="none"
              stroke="currentColor"
              stroke-width="2"
              stroke-linecap="round"
              stroke-linejoin="round"
              class="feather feather-x"
            >
              <line x1="18" y1="6" x2="6" y2="18"></line>
              <line x1="6" y1="6" x2="18" y2="18"></line>
            </svg>
          </button>
          <h3>Thêm mới cửa hàng</h3>
        </div>

        <!-- dòng mã cửa hàng  -->
        <div class="dialogContent">
          <div class="row" id="restaurantCode">
            <div class="fieldName">
              Mã cửa hàng
              <span>*</span>
            </div>
            <input
              type="text"
              id="inputRestaurantCode"
              v-model="restaurantToBinding.restaurantCode"
            />
          </div>
          <!-- Dòng tên cửa hàng  -->
          <div class="row" id="restaurantName">
            <div class="fieldName">
              Tên cửa hàng
              <span>*</span>
            </div>
            <input
              type="text"
              id="inputRestaurantName"
              v-model="restaurantToBinding.restaurantName"
            />
          </div>
          <!-- Địa chỉ  -->
          <div class="row" id="restaurantAddress">
            <div class="fieldName">
              Địa chỉ
              <span>*</span>
            </div>
            <!-- <input type="text" id="inputRestaurantAddress"> -->
            <textarea
              type="text"
              id="inputRestaurantAddress"
              rows="5"
              v-model="restaurantToBinding.address"
            ></textarea>
          </div>
          <!-- Số điện thoại và mã thuế  -->
          <div class="mergeHalfRow" id="phoneAndTax">
            <!-- số điện thoại  -->
            <div class="halfRow">
              <div class="fieldName">Số điện thoại</div>
              <input
                type="text"
                id="phoneNumber"
                v-model="restaurantToBinding.phoneNumber"
              />
            </div>
            <!-- thuế  -->
            <div class="halfRow">
              <div class="fieldName">Mã số thuế</div>
              <input
                type="text"
                id="taxCode"
                v-model="restaurantToBinding.taxCode"
              />
            </div>
          </div>
          <!-- Quốc gia  -->
          <div id="nation">
            <div class="halfRow">
              <div class="fieldName">Quốc gia</div>
              <select
                id="selectNation"
                v-model="restaurantToBinding.nationID"
                await
                v-on:change="onChangeNation($event)"
              >
                <option
                  value="00000000-0000-0000-0000-000000000000"
                  :disabled="true"
                >
                  Chọn Quốc gia
                </option>
                <option
                  v-for="nation in nations"
                  :key="nation.nationCode"
                  v-bind:value="nation.nationID"
                >
                  {{ nation.nationName }}
                </option>
              </select>
            </div>
          </div>
          <!-- tỉnh thành và quận huyện  -->
          <div class="mergeHalfRow" id="cityAndDistrict">
            <!-- tỉnh thành -->
            <div class="halfRow">
              <div class="fieldName">Tỉnh / Thành phố</div>
              <select
                id="selectCity"
                v-model="selectCity"
                await
                v-on:change="onChangeCity($event)"
              >
                <option
                  value="00000000-0000-0000-0000-000000000000"
                  :disabled="true"
                >
                  Chọn Tỉnh/Thành phố
                </option>
                <option
                  v-for="city in cities"
                  :key="city.cityCode"
                  v-bind:value="city.cityID"
                >
                  {{ city.cityName }}
                </option>
              </select>
            </div>

            <!-- quận huyện  -->
            <div class="halfRow">
              <div class="fieldName">Quận / Huyện</div>
              <select
                id="selectDistrict"
                v-model="restaurantToBinding.districtID"
                await
                v-on:change="onChangeDistrict($event)"
              >
                <option
                  value="00000000-0000-0000-0000-000000000000"
                  :disabled="true"
                >
                  Chọn Quận/Huyện
                </option>
                <option
                  v-for="district in districts"
                  :key="district.districtCode"
                  v-bind:value="district.districtID"
                >
                  {{ district.districtName }}
                </option>
              </select>
            </div>
          </div>
          <!-- Xã phường và phố  -->
          <div class="mergeHalfRow" id="communeAndStreet">
            <!-- xã phường  -->
            <div class="halfRow">
              <div class="fieldName">Phường / Xã</div>
              <select
                id="selectCommune"
                v-model="restaurantToBinding.communeID"
                await
                v-on:change="onChangeCommune($event)"
              >
                >
                <option
                  value="00000000-0000-0000-0000-000000000000"
                  :disabled="true"
                >
                  Chọn Xã/Phường
                </option>
                <option
                  v-for="commune in communes"
                  :key="commune.communeCode"
                  v-bind:value="commune.communeID"
                >
                  {{ commune.communeName }}
                </option>
              </select>
            </div>
            <!-- phố  -->
            <div class="halfRow">
              <div class="fieldName">Đường phố</div>
              <select id="selectStreet" v-model="restaurantToBinding.streetID">
                <option
                  value="00000000-0000-0000-0000-000000000000"
                  :disabled="true"
                >
                  Chọn Đường phố
                </option>
                <option
                  v-for="street in streets"
                  :key="street.streetCode"
                  v-bind:value="street.streetID"
                >
                  {{ street.streetName }}
                </option>
              </select>
            </div>
          </div>
        </div>
        <hr />
        <!-- footer dialog  -->
        <div class="dialogFooter">
          <div class="help">
            <div class="iconHelp"></div>
            <div style="color: #0088c1">Trợ giúp</div>
          </div>
          <div class="dialogFooterButtonBox">
            <button
              class="dialogFooterButton"
              id="buttonSave"
              @click="addRestaurant"
            >
              <div class="iconSave"></div>
              Lưu
            </button>
            <button
              class="dialogFooterButton"
              id="buttonSaveNew"
              @click="addAndNewRestaurant"
            >
              <div class="iconSaveNew"></div>
              Lưu và thêm mới
            </button>
            <button
              class="dialogFooterButton"
              id="buttonCancel"
              @click="closeDialog"
            >
              <div class="iconCancel"></div>
              Hủy bỏ
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import * as axios from "axios";

export default {
  name: "RestaurantListDetails",
  props: {
    restaurantToBinding: Object,
    cities: {
      type: Array,
      item: Object,
    },
  },

  data() {
    return {
      isShow: false,
      selectCity: this.restaurantToBinding.cityID,
      listData: [],
      nations: [],
      districts: [],
      communes: [],
      streets: [],
    };
  },

  computed: {
    validateData() {
      let returnData = {
        error: false,
        msg: "",
      };
      if (this.restaurantToBinding.restaurantCode == null) {
        returnData = {
          error: true,
          msg: "Vui lòng nhập mã cửa hàng",
        };
      }
      if (this.restaurantToBinding.restaurantName == null) {
        returnData = {
          error: true,
          msg: "Vui lòng chọn loại tên cửa hàng",
        };
      }
      if (this.restaurantToBinding.address == null) {
        returnData = {
          error: true,
          msg: "Vui lòng chọn địa chỉ",
        };
      }
      return returnData;
    },
  },

  methods: {
    /**
     * post restaurant
     */
    postRestaurant() {
      // Thực hiện post
      const response = axios
        .post(
          "https://localhost:44305/api/v1/restaurants",
          this.restaurantToBinding
        )
        .catch((e) => console.log(e));
      console.log(response);
    },

    /**
     * put res
     */
    putRestaurant() {
      // Thực hiện put
      const response = axios
        .put(
          "https://localhost:44305/api/v1/restaurants/" +
            this.restaurantToBinding.restaurantID,
          this.restaurantToBinding
        )
        .catch((e) => console.log(e));
      if (response) {
        alert(
          "Đã cập nhật thành công cửa hàng" +
            this.restaurantToBinding.restaurantName
        );
      }
      location.reload();
    },

    /**
     * sự kiện nút thêm
     */
    addRestaurant() {
      if (this.validateData.error) {
        alert(this.validateData.msg);
        console.log("chua validate");
      } else {
        if (
          this.restaurantToBinding.restaurantID ==
          "00000000-0000-0000-0000-000000000000"
        ) {
          this.postRestaurant();
        } else {
          this.putRestaurant();
        }
        this.closeDialog();
      }
    },

    /**
     * Hàm đóng form
     */
    closeDialog() {
      this.$store.dispatch("closeDialog");
    },

    /**
     * sự kiện lưu và thêm mới
     */
    addAndNewRestaurant() {
      if (this.validateData.error) {
        alert(this.validateData.msg);
      } else {
        if (
          this.restaurantToBinding.restaurantID ==
          "00000000-0000-0000-0000-000000000000"
        ) {
          this.postRestaurant();
        } else {
          this.putRestaurant();
        }
        this.closeDialog();
        // this.$store.dispatch("openDialog");
      }
    },

    /**
     * Khi người dùng chọn thông tin quốc gia --> thành phố thay đổi
     * Thì gọi api để lấy danh sách các tỉnh thành của quốc gia đang được chọn
     * createdby VTThien 21/02/21
     */
    async onChangeNation(event) {
      var nationID = event.target.value;
      const resCities = await axios.get(
        "https://localhost:44305/api/Cities/ByParent/" + nationID
      );
      this.cities = resCities.data.data;
    },

    /**
     * Khi người dùng chọn thông tin thành phố --> quận huyện thay đổi
     * Thì gọi api để lấy danh sách các quận huyện của tỉnh thành phố đang được chọn
     * createdby VTThien 21/02/21
     */
    async onChangeCity(event) {
      const resDistricts = await axios.get(
        "https://localhost:44305/api/Districts/ByParent/" + event.target.value
      );
      this.districts = resDistricts.data.data;
    },

    /**
     * Khi người dùng chọn thông tin quận huyện --> xã phường thay đổi
     * Thì gọi api để lấy danh sách các xã phường của quận huyện đang được chọn
     * createdby VTThien 21/02/21
     */
    async onChangeDistrict(event) {
      const resCommunes = await axios.get(
        "https://localhost:44305/api/Communes/ByParent/" + event.target.value
      );
      this.communes = resCommunes.data.data;
    },

    /**
     * Khi người dùng chọn thông tin xã phường --> đường phố thay đổi
     * Thì gọi api để lấy danh sách các đường phố của xã phường đang được chọn
     * createdby VTThien 21/02/21
     */
    async onChangeCommune(event) {
      const resStreets = await axios.get(
        "https://localhost:44305/api/Streets/ByParent/" + event.target.value
      );
      // console.log(resStreets);
      this.streets = resStreets.data.data;
    },
  },

  /**
   *
   * Lấy thông tin Quốc gia
   * Createdby Vtthien 21/02/21
   */
  async created() {
    const resNation = await axios.get("https://localhost:44305/api/Nations");
    // console.log(resNation);
    this.nations = resNation.data.data;
  },
};
</script>

<style scoped>
</style>