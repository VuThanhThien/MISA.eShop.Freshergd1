<template>
  <div>
    <div class="modal">
      <div class="modalMask"></div>
      <div class="popup">
        <div class="popupContent">
          <div class="iconConfirm"></div>
          <div class="message">
            Thành công
          </div>
        </div>
        <hr />
        <div class="dialogFooter" style="justify-content: flex-end">
          <div class="dialogFooterButtonBox">
            <button
              class="dialogFooterButton"
              id="buttonCancel"
              @click="closePopupSuccess"
            >
              <div class="iconCancel"></div>
              OK
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {

  },

  methods: {
    closePopupSuccess() {
      this.$store.dispatch("closePopupSuccess");
    },

  },
  data() {
    return {
      showPopup: false,

    };
  },
};
</script>
