'use client'

import { useRouter } from 'next/navigation'

import { useCheckAuth } from '~models/account'

import links from '~packages/links'

export default function Home() {
	const router = useRouter()
	const isAuth = useCheckAuth()

	if (isAuth) {
		router.replace(links.books.index)
	} else {
		router.replace(links.login)
	}

	return null
}
