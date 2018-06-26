import Vue from 'vue'
import Router from 'vue-router'

Vue.use(Router)

export default new Router({
	routes: [
		{
			path: '/',
			meta: {
				title: '大厅',
				showBack: false,
				showTabbar: true
			},
			component: resolve => require(['@/view/home'], resolve)
		},
		{
			path: '/artificial',
			meta: {
				title: '客服',
				showBack: false,
				showTabbar: true
			},
			component: resolve => require(['@/view/artificial/index'], resolve)
		},
		{
			path: '/center',
			meta: {
				title: '我的',
				showBack: false,
				showTabbar: true
			},
			component: resolve => require(['@/view/center'], resolve)
		},
		{
			path: '/artificial/cc',
			meta: {
				title: '客服',
				showBack: true
			},
			component: resolve => require(['@/view/artificial/cc'], resolve)
		},
		{
			path: '/center/login',
			meta: {
				title: '登陆',
				showBack: true
			},
			component: resolve => require(['@/view/center/login'], resolve)
		},
		{
			path: '/center/register',
			meta: {
				title: '注册',
				showBack: true
			},
			component: resolve => require(['@/view/center/register'], resolve)
		},
	]
})
