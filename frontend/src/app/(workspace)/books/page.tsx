'use client'

import { Flex, Text } from '@gravity-ui/uikit'

import BooksByTopic, { BooksByTopicFetcher } from '~widgets/books-by-topic'
import TopicsMost from '~widgets/topics-most'

import { Section, Spacing } from '~packages/ui'

export default function BooksPage() {
	return (
		<>
			<Flex direction={'column'} gap={12}>
				<Section header={'Все книги'} variant={'display-3'}>
					<TopicsMost />
				</Section>
				<BooksByTopicFetcher />
				<BooksByTopic />
			</Flex>
		</>
	)
}
