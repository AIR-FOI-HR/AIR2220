package hr.foi.air.core

import hr.foi.air.core.entities.Item
import hr.foi.air.core.entities.Receipt
import hr.foi.air.core.entities.User

interface LoadDataItemListener {
    fun onItemLoaded(item: Item)
}

interface LoadDataPurchaseListener {
    fun onPurchaseLoaded(receipt: Receipt)
}

interface LoadDataUserListener {
    fun onUserLoaded(user: User)
}