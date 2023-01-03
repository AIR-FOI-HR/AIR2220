package hr.foi.air.database.views

import androidx.room.DatabaseView

@DatabaseView("SELECT " +
        "users.userId , " +
        "users.firstName, " +
        "users.lastName, " +
        "users.lastName, " +
        "users.notifications, " +
        "users.avatarUrl, " +
        "users.loggedIn FROM users")
data class CurrentUser(
    val userId:Int?,
    val firstName:String?,
    val lastName:String?,
    val notifications:Boolean?,
    val avatarUrl:String?,
    val loggedIn:Boolean?
)