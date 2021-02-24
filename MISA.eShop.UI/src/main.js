import Vue from 'vue'
import App from './App.vue'
import router from './router'
// import store from './store'
import { store } from './store/Store'
import vuetify from './plugins/vuetify';
import VueSimpleAlert from "vue-simple-alert";
import Notifications from 'vue-notification';

Vue.use(Notifications)
Vue.use(VueSimpleAlert);
Vue.config.productionTip = false

new Vue({
  router,
  store,
  vuetify,
  render: h => h(App)
}).$mount('#app')
