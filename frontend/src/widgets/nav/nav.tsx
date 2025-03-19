'use client'

import { Moon, Sun } from '@gravity-ui/icons'
import { ActionBar } from '@gravity-ui/navigation'
import { Icon, SegmentedRadioGroup, User } from '@gravity-ui/uikit'

import { account, accountFullName } from '~models/account'

import styles from './index.module.scss'

export default function Nav() {
	return (
		<ActionBar aria-label='Actions bar' className={styles.nav}>
			<ActionBar.Group pull='left'>
				<SegmentedRadioGroup
					name='group1'
					defaultValue='light'
					disabled
				>
					<SegmentedRadioGroup.Option value='light'>
						<Icon data={Sun} />
					</SegmentedRadioGroup.Option>
					<SegmentedRadioGroup.Option value='dark'>
						<Icon data={Moon} />
					</SegmentedRadioGroup.Option>
				</SegmentedRadioGroup>
			</ActionBar.Group>
			<ActionBar.Section>
				<ActionBar.Group pull='right'>
					<ActionBar.Item>
						<User
							avatar={{ text: accountFullName, theme: 'brand' }}
							name={account?.firstName}
							description={account?.email}
							size='m'
						/>
					</ActionBar.Item>
				</ActionBar.Group>
			</ActionBar.Section>
		</ActionBar>
	)
}
