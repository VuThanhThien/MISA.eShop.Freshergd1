<template>
  <div id="app">
      <Navbar />
      <Header />
      <Content />
  </div>
</template>

<script>
import Navbar from "@/components/layout/Navbar";
import Header from "@/components/layout/Header";
import Content from "@/components/layout/Content";

export default {
  name: "App",

  components: {
    Navbar,
    Header,
    Content,
  },

  data: () => ({
    //
  }),
};
</script>

<style>
@import './styles/index.css';

* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
  text-decoration:none;
}
body {
    margin: 0;
    font-family: GoogleSans-Regular !important;
    font-size: 13px !important;
}
</style>
