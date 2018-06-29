<template>
    <div id="app">
        <div v-if="isLayout">
            <layout>
                <template slot="content">
                    <router-view/>
                </template>
            </layout>
        </div>
        <div v-else>
            <router-view/>
        </div>
    </div>
</template>

<script>
import layout from "@/components/layout";

export default {
    name: "App",
    components: {
        layout
    },
    data() {
        return {
            isLayout: false
        };
    },
    updated() {
        this.isLayout = this.$route.meta.layout == undefined ? true : false;
        document.title = this.$route.name;
    }
};
</script>

<style>
body {
    background: #f4f4f4;
}
</style>
