package hr.foi.air.core.entities

import java.util.*

open class Item (
    var id: Int? = null,
    var name: String = "",
    var quantity: Int = 0,
    var price: Double = 0.0,
    var imageUrl: String = "",
    var active: Boolean = false,
)
