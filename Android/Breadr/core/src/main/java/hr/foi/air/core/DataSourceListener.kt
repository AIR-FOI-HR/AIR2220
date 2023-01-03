package hr.foi.air.core

import hr.foi.air.core.entities.Item
import hr.foi.air.core.entities.Receipt
import hr.foi.air.core.entities.User


interface ItemDataSourceListener {
    fun onItemLoaded(item: Item)
}

interface PurchaseDataSourceListener {
    fun onPurchaseLoaded(receipt: Receipt)
}

interface UserDataSourceListener {
    fun onUserLoaded(user: User)
}
interface AuthenticationDataSourceListener {
    fun onAuthenticationLoaded(status: Boolean)
}
