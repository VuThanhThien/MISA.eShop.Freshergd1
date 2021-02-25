<template>
     <div class="header">
         
         <!-- tiêu đề  -->
        <div class="title">Cửa hàng</div>

        <!-- thông tin tài khoản  -->
        <div class="accoutInforBox">
            <!-- chọn nhà hàng hiện tại  -->
            <select id="myRestaurant">
                <option>DODAVI- 160 HOÀNG HOA THÁM</option>
                <option>DODAVI- Cầu Giấy</option>
                <option>DODAVI- Nam Từ Liê,</option>
            </select>
            <!-- tài khoản hiện tại  -->
            <div class="accountInfor">
                <div class="accountAvatar"></div>
                <select class="accountName">
                    <option >qtht misa</option>
                </select>
                <!-- <div class="accountName">qtht misa</div> -->
                <!-- <div class="accountOption"></div> -->
            </div>
            <!-- nút gọi  -->
            <div class="callMe"></div>
            <!-- chuông  -->
            <div  class="bell">
                <div class="fa fa-bell fa-2x"></div>
            </div>
            <div class="question">
                <i id="iconquestion" class="fa fa-question-circle fa-2x" aria-hidden="true"></i>
            </div>
        </div>
        
    </div>
</template>
<style scoped>
.bell{
    margin: 0 15px 0 15px;
    color: #026b97;
}
.question{
    height: 60px;
    width: 60px;
    align-items: center;
    border-left: 1px solid rgb(160, 159, 159);
}
#iconquestion{
    color: #026b97;
    padding: 14px;
}
</style>