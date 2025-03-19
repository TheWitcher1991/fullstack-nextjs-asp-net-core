'use client'

import { Tab, TabList } from '@gravity-ui/uikit'
import { usePathname } from 'next/navigation'
import { useEffect, useState } from 'react'

import { IBook } from '~models/book'

import links from '~packages/links'

interface BookTabsProps {
	book: IBook
}

export default function BookTabs({ book }: BookTabsProps) {
	const [val, setVal] = useState('1')
	const pathname = usePathname()

	useEffect(() => {
		if (pathname.includes('author')) {
			setVal('2')
		}
	}, [pathname])

	return (
		<TabList value={val} size='l'>
			<Tab value='1' href={links.books.byId(book.id)}>
				О книге
			</Tab>
			<Tab value='2' href={links.books.author(book.id)}>
				Автор
			</Tab>
			<Tab
				value='3'
				counter={0}
				disabled={true}
				href={links.books.impressions(book.id)}
			>
				Впечатления
			</Tab>
			<Tab value='3' counter={0} disabled={true}>
				Цитаты
			</Tab>
			<Tab value='4' counter={0} disabled={true}>
				Читают
			</Tab>
		</TabList>
	)
}
