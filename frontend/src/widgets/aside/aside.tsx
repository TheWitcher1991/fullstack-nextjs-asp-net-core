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

import links from '~packages/links'

import styles from './aside.module.scss'

export default function Aside({ children }: PropsWithChildren) {
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
					id: '1',
					title: 'Книги',
					icon: Book,
					current: true,
					onItemClick: () => router.replace(links.books.index),
				},
				{
					id: '1',
					title: 'Избранное',
					icon: Bookmark,
				},
				{
					id: '2',
					title: 'Поиск',
					icon: Magnifier,
					onItemClick: () => router.replace(links.search),
				},
				{
					id: '2',
					title: 'Профиль',
					icon: Person,
					onItemClick: () => router.replace(links.profile),
				},
				{
					id: '3',
					title: 'Выход',
					icon: ArrowRightFromSquare,
					onItemClick: () => router.replace(links.login),
				},
				{
					id: '6',
					title: 'Добавить книгу',
					icon: Plus,
					onItemClick: () => router.replace(links.books.create),
					type: 'action',
				},
			]}
		/>
	)
}
