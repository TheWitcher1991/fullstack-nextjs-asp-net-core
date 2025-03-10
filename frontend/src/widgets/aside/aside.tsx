'use client'

import {
	ArrowRightFromSquare,
	Book,
	Bookmark,
	LogoNotion,
	Magnifier,
	Person,
	Plus,
} from '@gravity-ui/icons'
import { AsideHeader } from '@gravity-ui/navigation'
import { useRouter } from 'next/navigation'
import { Fragment, PropsWithChildren } from 'react'

import { useLogout } from '~models/account'

import links from '~packages/links'

import styles from './aside.module.scss'

export default function Aside({ children }: PropsWithChildren) {
	const logout = useLogout()
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
					title: 'Книги',
					icon: Book,
					current: true,
					onItemClick: () => router.replace(links.books.index),
				},
				{
					id: 'favorites',
					title: 'Избранное',
					icon: Bookmark,
				},
				{
					id: 'search',
					title: 'Поиск',
					icon: Magnifier,
					onItemClick: () => router.replace(links.search),
				},
				{
					id: 'profile',
					title: 'Профиль',
					icon: Person,
					onItemClick: () => router.replace(links.profile),
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
