import { useQuery } from '@tanstack/react-query'

import { accountServiceKeys } from '~models/account/account.config'
import { AccountRepository } from '~models/account/account.repository'
import { useAccountStore } from '~models/account/account.store'

export const useCheckAuth = () => {
	const user = useAccountStore(state => state.account?.id)

	return !!user
}

export const useProfile = () => {
	return useQuery({
		queryKey: [accountServiceKeys.profile],
		queryFn: () => AccountRepository.profile(),
	})
}
