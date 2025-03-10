import { useMutation } from '@tanstack/react-query'
import { useRouter } from 'next/navigation'
import toast from 'react-hot-toast'

import { AccountRepository } from '~models/account/account.repository'
import { logout } from '~models/account/account.store'
import {
	ILogin,
	IRegister,
	IUpdateAccount,
} from '~models/account/account.types'

import links from '~packages/links'

export const useLogin = () => {
	return useMutation({
		mutationFn: (data: ILogin) => AccountRepository.login(data),
	})
}

export const useRegister = () => {
	return useMutation({
		mutationFn: (data: IRegister) => AccountRepository.register(data),
	})
}

export const useUpdateAccount = () => {
	return useMutation({
		mutationFn: (data: IUpdateAccount) =>
			AccountRepository.updateProfile(data),
	})
}

export const useLogout = () => {
	const router = useRouter()

	const { mutateAsync } = useMutation({
		mutationFn: () => AccountRepository.logout(),
	})

	return async () => {
		logout()
		router.replace(links.login)
		await toast.promise(mutateAsync(undefined), {
			loading: 'Выход...',
			success: 'Выход',
			error: 'Возникла ошибка',
		})
	}
}
