<template>
    <div>
        <swiper :list="list"></swiper>
    </div>
</template>

<script>
import { Swiper, Group } from "vux";
export default {
  components: {
    Swiper
  },
  data() {
    return {
      list: [
        {
          url: "javascript:",
          img: "https://static.vux.li/demo/1.jpg",
          title: "送你一朵fua"
        },
        {
          url: "javascript:",
          img: "https://static.vux.li/demo/5.jpg",
          title: "送你一次旅行",
          fallbackImg: "https://static.vux.li/demo/3.jpg"
        }
      ]
    };
  }
};
</script>

<style>
</style>
