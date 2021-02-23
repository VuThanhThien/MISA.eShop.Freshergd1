import Vue from 'vue'
import App from './App.vue'
import router from './router'
import { store } from './store/Store'
import VueColumnsResizable from 'vue-columns-resizable';
import Notifications from 'vue-notification'
Vue.use(VueColumnsResizable);
Vue.use(Notifications);
Vue.config.productionTip = false

new Vue({
    router,
    store,
    render: h => h(App)
}).$mount('#app')