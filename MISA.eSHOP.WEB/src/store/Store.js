import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export const store = new Vuex.Store({
  state: {
    // idToDelete:"",
    isShow: false,
    showPopup: false,
  },
  mutations: {
    // rowOnClick(state){
    // }
    openDialog(state) {
      state.isShow = true;
    },
    closeDialog(state) {
      state.isShow = false;
    },
    openPopup(state) {
      state.showPopup= true;
    },
    closePopup(state) {
      state.showPopup = false;
    }
  },
  actions: {
    openDialog: ({ commit }) => {
      commit('openDialog');
    },
    closeDialog({ commit }) {
      commit('closeDialog');
    },
    openPopup: ({ commit }) => {
      commit('openPopup');
    },
    closePopup({ commit }) {
      commit('closePopup');
    },
  },
  modules: {
  }
})