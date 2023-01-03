package hr.foi.air.breadr.fragments

import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import hr.foi.air.breadr.R
import hr.foi.air.breadr.databinding.FragmentBuyBinding
import hr.foi.air.breadr.databinding.FragmentProfileBinding
import hr.foi.air.breadr.databinding.FragmentReceiptBinding
import hr.foi.air.core.LoadDataItemListener
import hr.foi.air.core.LoadDataPurchaseListener
import hr.foi.air.core.LoadDataUserListener
import hr.foi.air.core.entities.Item
import hr.foi.air.core.entities.User


class ProfileFragment : Fragment(), LoadDataUserListener {

    private lateinit var user: User
    private lateinit var binding: FragmentProfileBinding
    private var userLoadedFlag: Boolean = false
    private var viewReadyFlag: Boolean = false

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        // setup binding
        binding = FragmentProfileBinding.inflate(inflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        viewReadyFlag =  true
        super.onViewCreated(view, savedInstanceState)
        // displaying data:
        tryToDisplayData()
    }

    private fun tryToDisplayData() {
        if (userLoadedFlag && viewReadyFlag)
        {
            binding.tvEmailInput.setText(user.email)
            binding.tvPasswordInput.setText("********")
            binding.swNotificationsInput.isChecked = user.notifications
            binding.tvProfileName.text =  "$user.firstName $user.lastName"
        }
    }

    private fun updateProfileInformation() {
        TODO("push differences to database")
    }

    override fun onUserLoaded(user: User) {
        this.user = user
        userLoadedFlag = true
        tryToDisplayData()
    }
}