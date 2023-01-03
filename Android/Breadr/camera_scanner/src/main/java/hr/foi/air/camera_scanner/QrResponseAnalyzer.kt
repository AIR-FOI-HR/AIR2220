package hr.foi.air.camera_scanner

import android.util.Log
import com.google.gson.Gson

interface QrResponseAnalyzer {
    fun analyseResponse(response: String): Int? {
        var gson = Gson()
        var qrCodeResponse: Int? = null
        try {
            var json = gson.fromJson(response, QrCode::class.java)
            if(json.quantity>0) qrCodeResponse = json.gateId
        } catch (ex: Exception) {
            Log.d("Breadr", "scanned error: $ex")
        }
        return qrCodeResponse
    }
}