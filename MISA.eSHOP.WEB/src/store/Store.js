import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export const store = new Vuex.Store({
  state: {
    isShow: false,
    showPopup: false,
  },
  mutations: {
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