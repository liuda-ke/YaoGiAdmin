import Vue from 'vue'
import Router from 'vue-router'
import HelloWorld from '@/components/HelloWorld'
import index from '@/pages/index'
import icon from '@/pages/system/icon'
import form from '@/pages/template/form'
import Table from '@/pages/template/Table'
import right from '@/pages/tools/rightclick'
import draggable from '@/pages/draggabletemp/draggable'
import phone from '@/pages/MobileTemp/Phone'
import slider from '@/pages/MobileTemp/slider'
import userinfo from '@/pages/user/userinfo'
import login from '@/pages/user/login'

Vue.use(Router)

export default new Router({
  mode: "history",
    routes: [{
        path: '/',
        name: 'index',
        component: index,
        children: [{
            path: '/index',
            name: "icon",
            component: icon
        }, {
            path: '/HelloWorld',
            name: "HelloWorld",
            component: HelloWorld
        }, {
            path: '/form',
            name: 'form',
            component: form
        }, {
            path: '/Table',
            name: 'Table',
            component: Table
        }, {
            path: '/userinfo',
            name: 'userinfo',
            component: userinfo
        }]
    }, {
        path: '/right',
        name: 'right',
        component: right
    }, {
        path: '/draggable',
        name: 'draggable',
        component: draggable
    }, {
        path: '/phone',
        name: 'phone',
        component: phone
    }, {
        path: '/login',
        name: 'login',
        component: login
    }, {
        path: '/slider',
        name: 'slider',
        component: slider
    }]
})
