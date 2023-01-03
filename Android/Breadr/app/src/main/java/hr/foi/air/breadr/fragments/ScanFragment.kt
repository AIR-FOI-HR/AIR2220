package hr.foi.air.breadr.fragments

import android.Manifest
import android.content.Context
import android.content.pm.PackageManager
import android.graphics.drawable.Drawable
import android.os.Build
import android.os.Bundle
import android.util.Log
import android.view.*
import hr.foi.air.breadr.R
import android.widget.Toast
import android.widget.Toast.LENGTH_SHORT
import androidx.appcompat.content.res.AppCompatResources
import androidx.camera.core.*
import androidx.camera.lifecycle.ProcessCameraProvider
import androidx.camera.view.PreviewView
import androidx.core.app.ActivityCompat
import androidx.fragment.app.Fragment
import com.google.common.util.concurrent.ListenableFuture
import hr.foi.air.camera_scanner.QrCodeAnalyzer
import hr.foi.air.camera_scanner.QrResponseAnalyzer
import hr.foi.air.core.ScanOptionPresenter
import java.util.concurrent.ExecutorService
import java.util.concurrent.Executors


class ScanFragment : Fragment(), ScanOptionPresenter, QrResponseAnalyzer {

    // Sources:
    // Camera preview: https://developer.android.com/codelabs/camerax-getting-started#0
    // QR Scanner: https://www.youtube.com/@PhilippLackner

    private lateinit var cameraProviderFuture : ListenableFuture<ProcessCameraProvider>
    private lateinit var previewView : PreviewView
//    private lateinit var code : String
    private lateinit var cameraExecutor: ExecutorService
    private var imageCapture: ImageCapture? = null
//    private lateinit var binding: ActivityPurchaseBinding


    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        cameraExecutor = Executors.newSingleThreadExecutor()

        // TODO("ask correctly for camera permission")

        // checking permissions
        if (ActivityCompat.checkSelfPermission(
                requireContext(),
                Manifest.permission.CAMERA
            ) != PackageManager.PERMISSION_GRANTED
        ) {
            ActivityCompat.requestPermissions(
                requireActivity(), REQUIRED_PERMISSIONS, REQUEST_CODE_PERMISSIONS
            )
            Toast.makeText(context, "no permission", Toast.LENGTH_LONG).show()
            return
        }
    }
    override fun onDestroy() {
        super.onDestroy()
        cameraExecutor.shutdown()
    }


    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_scan, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        Log.e(TAG, "Use case binding failed")

        // CameraProvider
        cameraProviderFuture = ProcessCameraProvider.getInstance(requireContext())
        val cameraProvider = cameraProviderFuture.get()

        // preview
        previewView = view.findViewById<PreviewView>(R.id.previewView)
        val preview = Preview.Builder()
            .build()
            .also {
                it.setSurfaceProvider(previewView.surfaceProvider)
            }
        imageCapture = ImageCapture.Builder()
            .build()

        // image analyser
        val imageAnalyzer = ImageAnalysis.Builder()
            .build()
            .also {
                it.setAnalyzer(cameraExecutor, QrCodeAnalyzer { code ->
                    onCodeScanned(code)
                })
            }

        // Select back camera as a default
        val cameraSelector = CameraSelector.DEFAULT_BACK_CAMERA
        try {
            // Unbind use cases before rebinding
            cameraProvider.unbindAll()

            // Bind use cases to camera
            cameraProvider.bindToLifecycle(
                this, cameraSelector, preview, imageCapture, imageAnalyzer)

        } catch(exc: Exception) {
            Log.e(TAG, "Use case binding failed", exc)
        }
    }

    private fun onCodeScanned(code: String) {
        val gateId = analyseResponse(code)
        if(gateId != null) {
            // TODO(WTF ARE ALL THESE NULL ASSUMPTIONS??)
            requireActivity().supportFragmentManager.beginTransaction()
                .replace(R.id.fcv_purchase, BuyFragment(gateId))
                .commit()
        } else {
            Toast.makeText(context,"Incorrect code scanned", LENGTH_SHORT).show()
        }
    }

    override fun getIcon(context: Context): Drawable? {
        return AppCompatResources.getDrawable(context, R.drawable.ic_baseline_qr_code_scanner)
    }

    override fun getName(context: Context): String {
        return "QR Code Scanning"
    }

    override fun getFragment(): Fragment {
        return this
    }

    companion object {
        private const val TAG = "Breadr"
        private const val REQUEST_CODE_PERMISSIONS = 10
        private val REQUIRED_PERMISSIONS =
            mutableListOf (
                Manifest.permission.CAMERA,
                Manifest.permission.RECORD_AUDIO
            ).apply {
                if (Build.VERSION.SDK_INT <= Build.VERSION_CODES.P) {
                    add(Manifest.permission.WRITE_EXTERNAL_STORAGE)
                }
            }.toTypedArray()
    }
}
