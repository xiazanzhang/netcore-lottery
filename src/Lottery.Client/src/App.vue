<template>
	<div id="app" style="height:100%;">
		<view-box ref="viewBox" body-padding-top="45px" :body-padding-bottom="bottom">
			<x-header slot="header" :title="title" :left-options="{showBack: showBack}" style="width:100%;position:absolute;left:0;top:0;z-index:100;"></x-header>
			<router-view></router-view>
			<Tabbar slot="bottom" v-if="showTabbar">
				<tabbar-item selected link="/">
					<img slot="icon" src="./assets/icons/icon_1.png">
					<img slot="icon-active" src="./assets/icons/icon_6.png">
					<span slot="label">大厅</span>
				</tabbar-item>
				<tabbar-item show-dot>
					<img slot="icon" src="./assets/icons/icon_2.png">
					<img slot="icon-active" src="./assets/icons/icon_7.png">
					<span slot="label">活动</span>
				</tabbar-item>
				<tabbar-item>
					<img slot="icon" src="./assets/icons/icon_3.png">
					<img slot="icon-active" src="./assets/icons/icon_8.png">
					<span slot="label">充值</span>
				</tabbar-item>
				<tabbar-item link="/artificial">
					<img slot="icon" src="./assets/icons/icon_4.png">
					<img slot="icon-active" src="./assets/icons/icon_9.png">
					<span slot="label">客服</span>
				</tabbar-item>
				<tabbar-item link="/center">
					<img slot="icon" src="./assets/icons/icon_5.png">
					<img slot="icon-active" src="./assets/icons/icon_10.png">
					<span slot="label">我的</span>
				</tabbar-item>
			</Tabbar>
		</view-box>
	</div>
</template>


<script>
import { XHeader, Tabbar, TabbarItem, ViewBox } from "vux";

export default {
    name: "app",
    components: {
        XHeader,
        Tabbar,
        TabbarItem,
        ViewBox
    },
    data: () => {
        return {
            title: "",
            showBack: false,
            showTabbar: false,
            bottom: "0px"
        };
    },
    updated() {
        this.title = this.$route.meta.title;
        this.showBack = this.$route.meta.showBack;
        this.showTabbar = this.$route.meta.showTabbar || false;
        this.bottom = this.$route.meta.showTabbar ? "55px" : "0px";
    }
};
</script>

<style lang="less">
@import "~vux/src/styles/reset.less";

html,
body {
    height: 100%;
    width: 100%;
    overflow-x: hidden;
}

body {
    background-color: #fbf9fe;
}
</style>


