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
          <h3>Thông tin cửa hàng</h3>
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
              ref="inputRestaurantCode"
              placeholder="Nhập mã cửa hàng"
            />
          </div>
          <!-- Dòng tên cửa hàng  -->
          <div class="row" id="restaurantName">
            <div class="fieldName">
              Tên cửa hàng
              <span>*</span>
            </div>
            <input
              autofocus
              type="text"
              id="inputRestaurantName"
              v-model="restaurantToBinding.restaurantName"
              ref="inputRestaurantName"
              placeholder="Nhập tên cửa hàng"
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
              ref="inputAddress"
              placeholder="Nhập địa chỉ"
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
                @change="onChangeNation($event)"
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
                  :value="nation.nationID"
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
                id="selectedCity"
                v-model="selectedCity"
                await
                @change="onChangeCity($event)"
              >
                <option
                  value="00000000-0000-0000-0000-000000000000"
                  :disabled="true"
                >
                  Chọn Tỉnh/Thành phố
                </option>
                <!-- Todo dùng mixin  -->
                <option
                  v-for="city in cities"
                  :key="city.cityCode"
                  :value="city.cityID"
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
                @change="onChangeDistrict($event)"
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
                  :value="district.districtID"
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
                @change="onChangeCommune($event)"
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
                  :value="commune.communeID"
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
                  :value="street.streetID"
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
    // object cửa hàng để bind
    restaurantToBinding: Object,
  },

  data() {
    return {
      //biến đóng mở trạng thái form
      isShow: false,
      //id thành phố của res được lấy
      selectedCity: this.restaurantToBinding.cityID,
      // mảng quốc gia rỗng
      nations: [],
      //mảng quận huyện rỗng
      districts: [],
      //mảng xã phường rỗng
      communes: [],
      //mảng đường phố rỗng
      streets: [],
      cities: [],
    };
  },

  computed: {
    validateData() {
      let returnData = {
        error: false,
        msg: "",
      };
      //check data mã cửa hàng
      if (
        this.restaurantToBinding.restaurantCode == null ||
        this.restaurantToBinding.restaurantCode == ""
      ) {
        returnData = {
          error: true,
          msg: "Vui lòng nhập mã cửa hàng",
        };
      }
      //check data tên cửa hàng
      if (
        this.restaurantToBinding.restaurantName == null ||
        this.restaurantToBinding.restaurantName == ""
      ) {
        returnData = {
          error: true,
          msg: "Vui lòng chọn tên cửa hàng",
        };
      }
      //check data địa chỉ cửa hàng
      if (
        this.restaurantToBinding.address == null ||
        this.restaurantToBinding.address == ""
      ) {
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
      axios
        .post(
          "https://localhost:44305/api/v1/restaurants",
          this.restaurantToBinding
        )
        .then((response) => {
          if (response.data) {
            this.$notify({
              //thông báo thêm mới
              title: "Important message",
              text:
                "Thêm mới thành công cửa hàng " +
                this.restaurantToBinding.restaurantName,
            });
            // load lai trang sau 2s
            setTimeout(() => location.reload(), 2000);
          }
        })
        .catch((e) => {
          // console.log("response error : ", e.response.data);
          if (e.response.status == 400) {
            this.$notify({
              // bad request
              type: "error",
              title: "Important message",
              text: "Thêm mới cửa hàng thất bại (BAD REQUEST)",
            });
          }

          if (e.response.status == 500) {
            this.$notify({
              //Lỗi server
              title: "Important message",
              text: "Vui lòng liên hệ MISA để được hỗ trợ",
            });
          }
        });
    },

    /**
     * put res
     */
    putRestaurant() {
      // Thực hiện put
      axios
        .put(
          "https://localhost:44305/api/v1/restaurants/" +
            this.restaurantToBinding.restaurantID,
          this.restaurantToBinding
        )
        .then((response) => {
          if (response.status == 201) {
            console.log("log");
            this.$notify({
              //Sửa thành công
              type: "success",
              title: "Important message",
              text:
                "Đã cập nhật thành công cửa hàng " +
                this.restaurantToBinding.restaurantName,
            });
            // load lai trang sau 2s
            setTimeout(() => location.reload(), 2000);
          }
        })
        .catch((e) => {
          if (e.response.status == 400) {
            this.$notify({
              type: "error",
              title: "Important message",
              text:
                "Cập nhật thông tin cửa hàng thất bại : " +
                +e.response.data.devMsg,
            });
          }

          if (e.response.status == 500) {
            this.$notify({
              type: "error",
              title: "Important message",
              text: "Vui lòng liên hệ MISA để được hỗ trợ",
            });
          }
        });
    },

    /**
     * sự kiện nút thêm
     */
    addRestaurant() {
      if (this.validateData.error) {
        this.$notify({
          //Lỗi validate
          type: "warn",
          title: "Important message",
          text: this.validateData.msg,
        });
      } else {
        if (
          //Nếu object cửa hàng bind lên form mà chưa có id thì là thêm mới
          this.restaurantToBinding.restaurantID ==
          "00000000-0000-0000-0000-000000000000"
        ) {
          this.postRestaurant();
        } else {
          //nếu có id rồi thì là sửa
          this.putRestaurant();
        }

        this.closeDialog();
      }
    },

    /**
     * Hàm đóng form
     */
    closeDialog() {
      this.$emit("resetDataRestaurant");
      this.$store.dispatch("closeDialog");
    },

    /**
     * TODO
     * sự kiện lưu và thêm mới
     */
    addAndNewRestaurant() {
      if (this.validateData.error) {
        this.$notify({
          type: "warn",
          title: "Important message",
          text: this.validateData.msg,
        });
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

    //#region  các sự kiện khi trường địa chỉ cha thay đổi
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
    this.nations = resNation.data.data;

    const resCity = await axios.get("https://localhost:44305/api/Cities");
    this.cities = resCity.data.data;

    const resDistrict = await axios.get(
      "https://localhost:44305/api/Districts"
    );
    this.districts = resDistrict.data.data;

    const resCommunes = await axios.get("https://localhost:44305/api/Communes");
    this.communes = resCommunes.data.data;

    const resStreets = await axios.get("https://localhost:44305/api/Streets");
    this.streets = resStreets.data.data;
  },
  //#endregion
};
</script>

<style scoped>
textarea {
  resize: none;
}
</style>