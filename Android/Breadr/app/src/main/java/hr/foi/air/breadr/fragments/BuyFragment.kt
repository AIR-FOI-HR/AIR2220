package hr.foi.air.breadr.fragments

import android.content.Intent
import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import hr.foi.air.breadr.MainActivity
import hr.foi.air.breadr.R
import hr.foi.air.breadr.data.DataRepository
import hr.foi.air.breadr.databinding.FragmentBuyBinding
import hr.foi.air.core.LoadDataItemListener
import hr.foi.air.core.LoadDataUserListener
import hr.foi.air.core.entities.Item
import hr.foi.air.core.entities.User

class BuyFragment(gateId: Int): Fragment(), LoadDataItemListener, LoadDataUserListener {

    private var gateId: Int
    private lateinit var item: Item
    private lateinit var user: User
    private lateinit var binding: FragmentBuyBinding
    private var itemLoadedFlag: Boolean = false
    private var userLoadedFlag: Boolean = false
    private var viewReadyFlag: Boolean = false
    private var dataItemListener: LoadDataItemListener = this
    private var dataUserListener: LoadDataUserListener = this

    init {
        this.gateId = gateId
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        // linking buttons:
        binding.btnBuyConfirm.setOnClickListener { buyProduct() }
        binding.btnBuyCancel.setOnClickListener{ goHome() }
        // display data:
        viewReadyFlag = true
        tryToDisplayData()
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        // load data:
        DataRepository().loadItem(this.requireContext(), dataItemListener, gateId)
        DataRepository().loadProfile(this.requireContext(), dataUserListener)
        // Inflate the layout for this fragment
        binding = FragmentBuyBinding.inflate(inflater, container, false)
        return binding.root
    }

    private fun tryToDisplayData() {
        if (itemLoadedFlag && viewReadyFlag)
        {
            binding.tvItemName.text = item.name
            binding.tvItemPrice.text = item.price.toString()
            binding.tvItemQuantity.text = item.quantity.toString()
            // TODO(check if this works (imageresource needs to be int))
//            binding.ivItemPicture.setImageResource(item.imageUrl.toInt())
        }
    }

    override fun onItemLoaded(item: Item) {
        this.item = item
        itemLoadedFlag = true
        tryToDisplayData()
    }

    private fun buyProduct() {
        if (userLoadedFlag and itemLoadedFlag) {
            requireActivity().supportFragmentManager.beginTransaction()
                .replace(R.id.fcv_purchase, ReceiptFragment(gateId, 9))
                .commit()
        }
    }

    private fun goHome() {
        val intent = Intent(activity, MainActivity::class.java)
        activity?.startActivity(intent)
    }

    override fun onUserLoaded(user: User) {
        this.user = user
        userLoadedFlag = true
    }
}