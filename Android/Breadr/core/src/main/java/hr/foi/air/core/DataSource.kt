package hr.foi.air.core

import android.content.Context

interface ItemDataSource {
    fun loadItem(listener: ItemDataSourceListener, context: Context, gateId: Int)
}

interface PurchaseDataSource {
    fun loadPurchase(listener: PurchaseDataSourceListener, context: Context, gateId: Int, userId: Int)
}

interface UserDataSource {
    fun loadUser(listener: UserDataSourceListener, context: Context)
}

interface AuthenticationDataSource {
    fun authenticate(listener: AuthenticationDataSourceListener, context: Context, email: String, password: String)
}