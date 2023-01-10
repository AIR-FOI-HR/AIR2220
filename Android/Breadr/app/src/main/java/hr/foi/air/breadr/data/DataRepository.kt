package hr.foi.air.breadr.data

import android.content.Context
import hr.foi.air.core.*
import hr.foi.air.core.entities.Item
import hr.foi.air.core.entities.Receipt
import hr.foi.air.core.entities.User
import hr.foi.air.core.helpers.InternetCheck
import hr.foi.air.database.data.DbDataSource
import hr.foi.air.ws.WsDataSource

class DataRepository() {

    fun loadItem(context : Context, listener: LoadDataItemListener, gateId: Int) {
        // TODO("return error if not online")
        //check if device is online
        val internetCheck = InternetCheck()
        val isOnline = internetCheck.isOnline(context)


        val dataSource = WsDataSource()
        dataSource.loadItem(object : ItemDataSourceListener {
            override fun onItemLoaded(item: Item) {
                listener.onItemLoaded(item)
            }
        }, context, gateId)
    }

    fun loadPurchase(context : Context, listener: LoadDataPurchaseListener, gateId: Int, userId: Int) {
        // TODO("return error if not online")
        //check if device is online
        val internetCheck = InternetCheck()
        val isOnline = internetCheck.isOnline(context)


        val dataSource = WsDataSource()
        dataSource.loadPurchase(object : PurchaseDataSourceListener {
            override fun onPurchaseLoaded(receipt: Receipt) {
                listener.onPurchaseLoaded(receipt)
            }

        }, context, gateId, userId)
    }

    fun loadProfile(context : Context, listener: LoadDataUserListener) {
        val dataSource = DbDataSource(context)
        dataSource.loadUser(object : UserDataSourceListener {
            override fun onUserLoaded(user: User) {
                listener.onUserLoaded(user)
            }

        }, context)
    }

    //needs cheking
    fun loadLogin(context : Context, listener: LoadDataAuthenticationListener, username: String, password: String) {
        // TODO("return error if not online")
        //check if device is online
        val internetCheck = InternetCheck()
        val isOnline = internetCheck.isOnline(context)


        val dataSource = WsDataSource()
        dataSource.authenticate(object : AuthenticationDataSourceListener {
            override fun onAuthenticationLoaded(status: Boolean) {
                listener.onAuthenticationLoaded(status)
            }

        }, context, username, password)
    }

    //not finished, not sure if listener is correct
    /**
    fun loadSignup(context : Context, listener: LoadDataAuthenticationListener, name: String, surname: String, username: String, email:String, password:String){
        // TODO("return error if not online")
        //check if device is online
        val internetCheck = InternetCheck()
        val isOnline = internetCheck.isOnline(context)


        val dataSource = WsDataSource()
        dataSource.authenticate(object : AuthenticationDataSourceListener {
            override fun onAuthenticationLoaded(status: Boolean) {
                listener.onAuthenticationLoaded(status)
            }

        }, context, name, surname, username, email, password)
    }**/
}