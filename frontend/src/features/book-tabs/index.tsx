import { Tab, TabList } from '@gravity-ui/uikit'

import { IBook } from '~models/book'

interface BookTabsProps {
	book: IBook
}

export default function BookTabs({ book }: BookTabsProps) {
	return (
		<TabList value='1' size='l'>
			<Tab value='1'>О книге</Tab>
			<Tab value='2'>Автор</Tab>
			<Tab value='3' counter={0}>
				Впечатления
			</Tab>
			<Tab value='4' counter={0}>
				Читают
			</Tab>
		</TabList>
	)
}
