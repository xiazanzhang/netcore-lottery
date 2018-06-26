// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import Vuex from 'vuex'

import store from './vuex/store'
import router from './router'
import components from './components'
import directives from './directives/directives'
import ajax from './plugins/ajax'
import loading from './plugins/loading'
import api from './api/index'

Vue.config.productionTip = false
Vue.prototype.api = api
Vue.use(ajax)
Vue.use(loading)

Vue.http.defaults.baseURL = 'https://api.example.com'

Object.keys(components).forEach((key) => {
	Vue.component(key, components[key])
	Vue.prototype.$Loading = components['LoadingBar']
	Vue.prototype.$Message = components['Message']
	Vue.prototype.$Modal = components['Modal']
	Vue.prototype.$Notice = components['Notice']
})

/* eslint-disable no-new */
new Vue({
	el: '#app',
	store,
	router,
	render: h => h(App)
})