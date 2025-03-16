import { Flex, Text } from '@gravity-ui/uikit'
import { useRouter } from 'next/navigation'
import { CSSProperties } from 'react'

import { IBook } from '~models/book'

import links from '~packages/links'

interface BooksMostListProps {
	books: IBook[]
}

const pointStyle: CSSProperties = {
	backgroundColor: 'var(--g-color-text-primary)',
	width: '4px',
	height: '4px',
	borderRadius: '50%',
}

const textStyle: CSSProperties = {
	cursor: 'pointer',
}

function Point() {
	return <div style={pointStyle}></div>
}

export default function BooksMostList({ books }: BooksMostListProps) {
	const router = useRouter()

	return books.map(book => (
		<Flex key={book.id} alignItems={'center'} gap={2} wrap={'nowrap'}>
			<Text
				style={textStyle}
				variant={'body-2'}
				color={'dark-secondary'}
				onClick={() => router.push(links.books.byId(book.id))}
			>
				{book.title}
			</Text>
			<Point />
		</Flex>
	))
}
