package hr.foi.air.ws

import android.util.Log
import hr.foi.air.core.entities.Item
import hr.foi.air.core.entities.Receipt
import hr.foi.air.ws.handlers.WebServiceHandler
import hr.foi.air.ws.responses.ItemResponse
import hr.foi.air.ws.responses.PurchaseResponse
import okhttp3.OkHttpClient
import retrofit2.*
import retrofit2.converter.gson.GsonConverterFactory

class WebServiceCaller {
    private val TAG = "Breadr"

    private lateinit var retrofit: Retrofit

    // TODO("change to production URL")
    private val baseUrl: String = "http://10.0.2.2:8000/breadr/"

    init {
        retrofit = Retrofit.Builder()
            .baseUrl(baseUrl)
            .addConverterFactory(GsonConverterFactory.create())
            .client(OkHttpClient())
            .build()
    }

    fun getItem(id: Int, dataArrivedHandler: WebServiceHandler) {
        var serviceAPI = retrofit.create(WebService::class.java)
        var call: Call<ItemResponse> = serviceAPI.getProduct(id)

        call.enqueue(
            object : Callback<ItemResponse> {
                override fun onResponse(
                    call: Call<ItemResponse>,
                    response: Response<ItemResponse>
                ) {
                    try {
                        if (response != null && response.isSuccessful) {
                                response.body()?.let {
                                    dataArrivedHandler.onItemArrived<Item>(
                                        it.transform(), true, response.body()?.timeStamp
                                    )
                                }
                        } else {
                            Log.d(TAG, "global error")
                            //TODO("an error occurred")
                        }
                    } catch (ex: Exception) {
                        Log.d(TAG, "error occurred: $ex")
                        //TODO("Response processing exception")
                    }
                }

                override fun onFailure(call: Call<ItemResponse>, t: Throwable) {
                    Log.d(TAG, "global failure: $t")
                    TODO("Not yet implemented")
                }
            }
        )
    }

    fun buyProduct(gateId: Int, dataArrivedHandler: WebServiceHandler, userId: Int) {
        var serviceAPI = retrofit.create(WebService::class.java)
        // TODO("remove hard coded user id")
        var call: Call<PurchaseResponse> = serviceAPI.buyProduct(userId, gateId)

        call.enqueue(
            object : Callback<PurchaseResponse> {
                override fun onResponse(
                    call: Call<PurchaseResponse>,
                    response: Response<PurchaseResponse>
                ) {
                    try {
                        if (response != null && response.isSuccessful) {
                            dataArrivedHandler.onPurchaseArrived<Receipt>(
                                // TODO(change null assertion)
                                response.body()!!.transform(), true, response.body()?.timeStamp
                            )
                        } else {
                            Log.d(TAG, "global error")
                            //TODO("an error occurred")
                        }
                    } catch (ex: Exception) {
                        Log.d(TAG, "error occurred: $ex")
                        //TODO("Response processing exception")
                    }
                }

                override fun onFailure(call: Call<PurchaseResponse>, t: Throwable) {
                    Log.d(TAG, "global failure: $t")
                    TODO("Not yet implemented")
                }
            }
        )
    }

    // transforms itemresponse to item
    fun ItemResponse.transform(): Item {
        // if(!(this::class.java.declaredFields.contains(null)))
        // if(this.active != null && this.id != null && this.quantity != null && this.price != null && this.name != null) {
            return Item(
                id = this.id,
                name = this.name,
                quantity = this.quantity,
                price = this.price,
                active = this.active,
                imageUrl = this.imageUrl
            )
    }

    // transforms a single object
    fun PurchaseResponse.transform(): Receipt {
        // if(this.gateId != null) this.gateId else null
            return Receipt(
                gateId = this.gateId,
                status = this.transactionStatus,
                name = this.name,
                price = this.price
            )
    }
}

