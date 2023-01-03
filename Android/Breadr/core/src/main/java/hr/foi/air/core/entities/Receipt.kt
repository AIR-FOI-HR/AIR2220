package hr.foi.air.core.entities

open class Receipt(
    open var gateId: Int? = null,
    var status: Boolean = false,
    var name: String = "",
    var price: Double = 0.0
)