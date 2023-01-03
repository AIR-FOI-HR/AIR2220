package hr.foi.air.database.views

import androidx.room.DatabaseView

@DatabaseView("SELECT " +
        "receipts.gateId, " +
        "receipts.name, " +
        "receipts.status, " +
        "receipts.price FROM receipts")
data class ReceiptInfo(
    val gateId:Int?,
    val name:String?,
    val status:Boolean?,
    val price:Double?
)