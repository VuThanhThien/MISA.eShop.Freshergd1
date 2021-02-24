import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export const store = new Vuex.Store({
    state: {
        // idToDelete:"",
        isShow: false,
        showPopup: false,
        showPopupSuccess: false,
        snackbar: false,
    },
    mutations: {
        openSnackbar(state){
            state.snackbar = true;
        },

        openDialog(state) {
            state.isShow = true;
        },
        closeDialog(state) {
            state.isShow = false;
        },
        openPopup(state) {
            state.showPopup = true;
        },
        closePopup(state) {
            state.showPopup = false;
        },
        openPopupSuccess(state) {
            state.showPopupSuccess = true;
        },
        closePopupSuccess(state) {
            state.showPopupSuccess = false;
        }
    },
    actions: {
        openSnackbar: ({ commit }) => {
            commit('openSnackbar');
        },

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
        openPopupSuccess: ({ commit }) => {
            commit('openPopupSuccess');
        },
        closePopupSuccess({ commit }) {
            commit('closePopupSuccess');
        },
    },
    modules: {}
})