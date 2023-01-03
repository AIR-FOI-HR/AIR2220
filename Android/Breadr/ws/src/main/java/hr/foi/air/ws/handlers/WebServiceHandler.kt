package hr.foi.air.ws.handlers

import hr.foi.air.core.entities.Item
import hr.foi.air.core.entities.Receipt
import java.sql.Timestamp

interface WebServiceHandler {
    fun <T> onItemArrived(result: Item, ok: Boolean, timestamp: Long?)
    fun <T> onPurchaseArrived(result: Receipt, ok: Boolean, timestamp: Long?)
    fun <T> onAuthenticationArrived(result: Boolean, ok: Boolean, timestamp: Long?)
}