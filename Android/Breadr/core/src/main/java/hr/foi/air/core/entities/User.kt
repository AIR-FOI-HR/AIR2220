package hr.foi.air.core.entities

open class User(
    open var userId: Int? = null,
    var email: String? = "",
    var avatarUrl : String = "",
    var loggedIn: Boolean = false,
    var password : String = "",
    var firstName: String = "",
    var lastName: String = "",
    var notifications: Boolean = true
)
