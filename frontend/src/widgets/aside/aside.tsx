'use client'

import {
	ArrowRightFromSquare,
	Book,
	Bookmark,
	CreditCard,
	LogoNotion,
	Magnifier,
	Person,
	Plus,
} from '@gravity-ui/icons'
import { AsideHeader } from '@gravity-ui/navigation'
import { usePathname, useRouter } from 'next/navigation'
import { Fragment, PropsWithChildren } from 'react'

import { useLogout } from '~models/account'

import links from '~packages/links'

import styles from './aside.module.scss'

export default function Aside({ children }: PropsWithChildren) {
	const logout = useLogout()
	const pathname = usePathname()
	const router = useRouter()

	return (
		<AsideHeader
			logo={{
				className: styles.aside,
				iconClassName: styles.aside,
				icon: LogoNotion,
				text: 'TALENTSPOT Строки',
				iconSize: 26,
				textSize: 16,
				onClick: () => router.replace(links.home),
			}}
			compact={false}
			hideCollapseButton={true}
			headerDecoration={true}
			renderContent={() => <>{children}</>}
			menuItems={[
				{
					id: 'books',
					title: 'Главное',
					icon: Book,
					current: pathname.startsWith(links.books.index),
					onItemClick: () => router.replace(links.books.index),
				},
				{
					id: 'favorites',
					title: 'Мои книги',
					icon: Bookmark,
					current: pathname.startsWith(links.favorites),
					onItemClick: () => router.replace(links.favorites),
				},
				{
					id: 'search',
					title: 'Поиск',
					icon: Magnifier,
					current: pathname.startsWith(links.search),
					onItemClick: () => router.replace(links.search),
				},
				{
					id: 'profile',
					title: 'Профиль',
					icon: Person,
					current: pathname.startsWith(links.profile),
					onItemClick: () => router.replace(links.profile),
				},
				{
					id: 'billing',
					title: 'Биллинг',
					icon: CreditCard,
					current: pathname.startsWith(links.billing),
					onItemClick: () => router.replace(links.billing),
				},
				{
					id: 'logout',
					title: 'Выход',
					icon: ArrowRightFromSquare,
					onItemClick: async () => await logout(),
				},
				{
					id: 'create',
					title: 'Добавить книгу',
					icon: Plus,
					onItemClick: () => router.replace(links.books.create),
					type: 'action',
				},
			]}
		/>
	)
}
