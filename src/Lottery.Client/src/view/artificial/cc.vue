<template>
    <div style="overflow: hidden;">
        <iframe id="iframe" class="iframe" :src="url" width="100%" :height="height"></iframe>
    </div>
</template>

<script>
export default {
    created() {
        this.url = ysf.url();
        this.height = document.documentElement.clientHeight - 45;
    },
    data: () => {
        return {
            url: "",
            height: ""
        };
    }
};
</script>

<style>
.iframe {
    border: 0;
}
</style>
