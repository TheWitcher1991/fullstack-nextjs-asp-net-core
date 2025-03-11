'use client'

import { Flex } from '@gravity-ui/uikit'

import BooksMost from '~widgets/books-most'
import BooksSearch from '~widgets/books-search'
import TopicsMost from '~widgets/topics-most'

import { Section } from '~packages/ui'

export default function SearchPage() {
	return (
		<Flex direction={'column'} gap={'12'}>
			<BooksSearch />
			<BooksMost />
			<Section header={'Категории'}>
				<TopicsMost />
			</Section>
		</Flex>
	)
}
