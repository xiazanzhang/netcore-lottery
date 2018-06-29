import Vue from 'vue'
import Router from 'vue-router'


Vue.use(Router)

let router = new Router({
	routes: [
		{
			path: '/',
			name: '首页',
			component: resolve => require(['@/view/index'], resolve)
		},
		{
			path: '/login',
			name: '登陆',
			meta: {
				layout: false
			},
			component: resolve => require(['@/view/sys/login'], resolve)
		}
	]
})

export default router