<template>
    <div id="app">
        <left-menu>
            <template slot="content">
                <router-view class="router-view"></router-view>
            </template>
        </left-menu>
    </div>
</template>

<script>
import Menu from "./components/menu";

export default {
    components: {
        LeftMenu: Menu
    }
};
</script>

<style lang="less">
@import "~iview/dist/styles/iview.css";
@import "assets/style/global.less";
@import "https://cdn.bootcss.com/animate.css/3.5.2/animate.css";
</style>