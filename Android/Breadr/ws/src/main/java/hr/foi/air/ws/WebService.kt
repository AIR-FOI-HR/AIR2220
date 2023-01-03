package hr.foi.air.ws

import hr.foi.air.ws.responses.ItemResponse
import hr.foi.air.ws.responses.LoginResponse
import hr.foi.air.ws.responses.PurchaseResponse
import hr.foi.air.ws.responses.RegisterResponse
import retrofit2.Call
import retrofit2.http.Headers
import retrofit2.http.POST
import retrofit2.http.Query

interface WebService {
    @Headers("Content-Type: application/json")
    @POST("getProduct")
    fun getProduct(@Query("gate_id") gateId : Int) : Call<ItemResponse>

    @Headers("Content-Type: application/json")
    @POST("buyProduct")
    fun buyProduct(@Query("user_id") userId : Int, @Query("gate_id") gateId: Int) : Call<PurchaseResponse>

    @Headers("Content-Type: application/json")
    @POST("login")
    fun logIn(@Query("email") email : String, @Query("password") password: String) : Call<LoginResponse>

    @Headers("Content-Type: application/json")
    @POST("register")
    fun register(@Query("firstName") firstName : String,
                 @Query("lastName") lastName : String,
                 @Query("email") email : String,
                 @Query("password") password: String) : Call<RegisterResponse>
}