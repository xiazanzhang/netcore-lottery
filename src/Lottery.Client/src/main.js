// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import FastClick from 'fastclick'
import VueRouter from 'vue-router'
import router from './router/index'
import App from './App'
import api from './api/api'
import storage from './libs/storage'
import { AjaxPlugin } from 'vux'
import { LoadingPlugin } from 'vux'
import { ToastPlugin } from 'vux'
import  { AlertPlugin } from 'vux'

Vue.prototype.api = api
Vue.prototype.storage=storage

Vue.use(VueRouter)
Vue.use(AjaxPlugin)
Vue.use(LoadingPlugin)
Vue.use(ToastPlugin)
Vue.use(AlertPlugin)

FastClick.attach(document.body)

Vue.config.productionTip = false

/* eslint-disable no-new */
new Vue({
	router,
	render: h => h(App)
}).$mount('#app-box')
