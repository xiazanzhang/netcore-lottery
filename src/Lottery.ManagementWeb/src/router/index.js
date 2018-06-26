//文档地址：https://router.vuejs.org/zh-cn/

import Vue from 'vue'
import VueRouter from 'vue-router'

Vue.use(VueRouter)

const routes = [
    {
        path: '/',
        name: '/',
        component: resolve => require(['@/view/home/index'], resolve)
    },
    {
        path: '/member',
        name: 'member',
        component: resolve => require(['@/view/member/index'], resolve)
    }
]

//路由配置
const RouterConfig = {
    mode: 'history',
    routes: routes
}

const router = new VueRouter(RouterConfig)

export default router