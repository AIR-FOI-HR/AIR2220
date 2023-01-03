package hr.foi.air.ws

import android.content.Context
import hr.foi.air.core.ItemDataSource
import hr.foi.air.core.ItemDataSourceListener
import hr.foi.air.core.PurchaseDataSource
import hr.foi.air.core.PurchaseDataSourceListener
import hr.foi.air.core.entities.Item
import hr.foi.air.ws.handlers.WebServiceHandler
import hr.foi.air.core.entities.Receipt

class WsDataSource : ItemDataSource, PurchaseDataSource {
    lateinit var item : Item
    lateinit var receipt: Receipt
    private lateinit var itemListener: ItemDataSourceListener
    private lateinit var purchaseListener: PurchaseDataSourceListener

    var itemArrived = false
    var purchaseArrived = false

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
        }

}