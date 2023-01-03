package hr.foi.air.ws

import android.content.Context
import hr.foi.air.core.*
import hr.foi.air.core.entities.Item
import hr.foi.air.ws.handlers.WebServiceHandler
import hr.foi.air.core.entities.Receipt

class WsDataSource : ItemDataSource, PurchaseDataSource, AuthenticationDataSource {
    lateinit var item : Item
    lateinit var receipt: Receipt
    private lateinit var itemListener: ItemDataSourceListener
    private lateinit var purchaseListener: PurchaseDataSourceListener
    private lateinit var authenticationListener: AuthenticationDataSourceListener

    var itemArrived = false
    var purchaseArrived = false
    var authArrived = false

    override fun loadItem(listener: ItemDataSourceListener, context: Context, gateId: Int) {
        this.itemListener = listener

        val itemCaller = WebServiceCaller()

        itemCaller.getItem(gateId, dataHandler)
    }
    override fun loadPurchase(listener: PurchaseDataSourceListener, context: Context, gateId: Int, userId: Int) {
        this.purchaseListener = listener

        val purchaseCaller = WebServiceCaller()

        purchaseCaller.buyProduct(gateId, dataHandler, userId)
    }

    @Suppress("UNCHECKED_CAST")
    private val dataHandler : WebServiceHandler =
        object : WebServiceHandler{
            override fun <T> onItemArrived(result: Item, ok: Boolean, timestamp: Long?) {
                if(ok) item = result as Item
                itemArrived = true
                itemListener.onItemLoaded(item)
            }
            override fun <T> onPurchaseArrived(result: Receipt, ok: Boolean, timestamp: Long?) {
                if(ok) receipt = result as Receipt
                purchaseArrived = true
                purchaseListener.onPurchaseLoaded(receipt)
            }

            override fun <T> onAuthenticationArrived(
                result: Boolean,
                ok: Boolean,
                timestamp: Long?
            ) {
                authArrived = true
                authenticationListener.onAuthenticationLoaded(result)
            }
        }

    override fun authenticate(listener: AuthenticationDataSourceListener, context: Context, email: String, password: String) {
        this.authenticationListener = listener

        val authenticationCaller = WebServiceCaller()

        authenticationCaller.logInUser(dataHandler, email, password)
    }

}