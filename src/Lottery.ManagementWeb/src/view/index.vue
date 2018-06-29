<template>
    <div>
        <Button @click.native="login">Default</Button>
    </div>
</template>

<script>
export default {
    methods: {
        login() {
            this.$router.push({
                path: "/login"
            });
        }
    }
};
</script>

<style>
</style>
