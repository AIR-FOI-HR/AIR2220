package hr.foi.air.database.entities

import androidx.room.*
import hr.foi.air.database.converters.DateConverter
import hr.foi.air.core.entities.Receipt


@Entity(tableName = "receipts", primaryKeys = ["gateId"])
@TypeConverters(DateConverter::class)
class Receipt() : Receipt() {
    @PrimaryKey(autoGenerate = true)
    @Ignore
    override var gateId: Int? = null
}