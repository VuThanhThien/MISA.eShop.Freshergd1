<template>
    <div class="navbar">
        <router-link class="logoSite" to="/Home">
            <div class="logoBox">
                <div class="amisLogo"></div>
            </div>
        </router-link>
        <div class="navbarContent">
            <a class="navbarItem">
                <div class="navbarItemIcon navbarItemDashboard"></div>
                <div class="navbarItemText">Tổng quan</div>
            </a>
            <a class="navbarItem">
                <div class="navbarItemIcon navbarItemReport"></div>
                <div class="navbarItemText">Báo cáo</div>
            </a>
            <a class="navbarItem">
                <div class="navbarItemIcon navbarItemOrder"></div>
                <div class="navbarItemText">Đơn hàng</div>
            </a>
            <a class="navbarItem" >
                <div class="navbarItemIcon navbarItemDic"></div>
                <div class="navbarItemText">Mua hàng</div>
            </a>
             <router-link class="navbarItem" to="/dictionary/saleoff">
                <div class="navbarItemIcon navbarItemSale"></div>
                <div class="navbarItemText">Khuyến mại</div>
            </router-link>
            <router-link class="navbarItem" to="/dictionary/restaurant">
                <div class="navbarItemIcon navbarItemSetting"></div>
                <div class="navbarItemText">Quản lý cửa hàng</div>
            </router-link>
            <a class="navbarItem">
                <div class="navbarItemIcon navbarItemStock"></div>
                <div class="navbarItemText">Hàng hóa</div>
            </a>

        </div>
    </div>
</template>
<script>
export default {
  name: 'MenuBarLinks',
  data () {
    return {
      employee: '/dictionary/restaurant'
    };
  }
};
</script>
