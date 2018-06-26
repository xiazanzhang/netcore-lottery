<template>
    <div>
        <Button @click="clicked">Ajax调用示例</Button>
    </div>
</template>

<script>
    export default {
        methods: {
            clicked() {
                //Ajax调用示例
                this.api.test.joke().then((res) => {
                    console.log(res)
                })
            }
        }
    }

</script>